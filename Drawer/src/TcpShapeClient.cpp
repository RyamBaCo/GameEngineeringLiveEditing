#include "TcpShapeClient.h"

using namespace ci;
using namespace ci::app;

TcpShapeClient::TcpShapeClient()
	:	isConnected(false), 
		isClosing(false),
		socket(ioService), 
		heartBeatTimer(ioService), 
		reconnectTimer(ioService)
{	
	// for servers that terminate their messages with a null-byte
	delimiter = "\0"; 
}

TcpShapeClient::~TcpShapeClient(void)
{
	disconnect();
}

void TcpShapeClient::setDelimiter(const std::string &delimiter)
{ 
	this->delimiter = delimiter; 
}

void TcpShapeClient::update()
{
	ioService.poll();
}

void TcpShapeClient::connect(const std::string &ip, unsigned short port)
{
	try 
	{
		boost::asio::ip::tcp::endpoint endpoint(boost::asio::ip::address::from_string(ip), port);
		connect(endpoint);
	}
	catch(const std::exception &e) 
	{
		ci::app::console() << "Server exception:" << e.what() << std::endl;
	}
}

void TcpShapeClient::connect(boost::asio::ip::tcp::endpoint& endpoint)
{
	if(isConnected || isClosing) 
		return;

	endPoint = endpoint;
	socket.async_connect(endpoint,
        boost::bind(&TcpShapeClient::handle_connect, this, boost::asio::placeholders::error));
}

void TcpShapeClient::disconnect()
{		
	close();
	ioService.stop();
	isConnected = false;
	isClosing = false;
}

void TcpShapeClient::close()
{
	if(!isConnected) 
		return;

	ioService.post(boost::bind(&TcpShapeClient::do_close, this));
}

void TcpShapeClient::read()
{
	if(!isConnected ||isClosing) 
		return;

	boost::asio::async_read_until(socket, buffer, delimiter,
          boost::bind(&TcpShapeClient::handle_read, this, boost::asio::placeholders::error));
}

void TcpShapeClient::handle_connect(const boost::system::error_code& error) 
{
	if(isClosing) 
		return;
	
	if (!error) 
	{
		isConnected = true;
		sConnected(endPoint);

		heartBeatTimer.expires_from_now(boost::posix_time::seconds(5));
		heartBeatTimer.async_wait(boost::bind(&TcpShapeClient::do_heartbeat, this, boost::asio::placeholders::error));

		read();
	}
	else 
	{
		isConnected = false;
		ci::app::console() << "Server error: " << error.message() << std::endl;

		// schedule a timer to reconnect after 5 seconds		
		reconnectTimer.expires_from_now(boost::posix_time::seconds(5));
		reconnectTimer.async_wait(boost::bind(&TcpShapeClient::do_reconnect, this, boost::asio::placeholders::error));
	}
}

void TcpShapeClient::handle_read(const boost::system::error_code& error)
{
	if (!error)
	{
		std::string msg;
		std::istream is(&buffer);
		std::getline(is, msg); 
		
		if(msg.empty()) 
			return;

		// create signal to notify listeners
		sMessage(msg);

		heartBeatTimer.expires_from_now(boost::posix_time::seconds(5));
		heartBeatTimer.async_wait(boost::bind(&TcpShapeClient::do_heartbeat, this, boost::asio::placeholders::error));

		read();
	}
	else
	{
		// try to reconnect if external host disconnects
		if(error.value() != 0) 
		{
			isConnected = false;
			sDisconnected(endPoint); 
			
			// schedule a timer to reconnect after 5 seconds
			reconnectTimer.expires_from_now(boost::posix_time::seconds(5));
			reconnectTimer.async_wait(boost::bind(&TcpShapeClient::do_reconnect, this, boost::asio::placeholders::error));
		}
		else
			do_close();
	}
}

void TcpShapeClient::do_close()
{
	if(isClosing) 
		return;
	
	isClosing = true;
	socket.close();
}

void TcpShapeClient::do_reconnect(const boost::system::error_code& error)
{
	if(isConnected || isClosing) 
		return;

	socket.close();
	socket.async_connect(endPoint,
        boost::bind(&TcpShapeClient::handle_connect, this, boost::asio::placeholders::error));
}

void TcpShapeClient::do_heartbeat(const boost::system::error_code& error)
{
}

