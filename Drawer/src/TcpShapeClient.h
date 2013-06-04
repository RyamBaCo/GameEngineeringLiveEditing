// this is a modified version of tcp client sample for cinder: https://github.com/paulhoux/Cinder-Samples/blob/master/TcpClient/src/TcpClientApp.cpp

#pragma once

#ifdef WIN32
    #include <sdkddkver.h>
#endif

#include <string>
#include <iostream>
#include <boost/asio.hpp>
#include <boost/bind.hpp>
#include <boost/date_time/posix_time/posix_time.hpp>
#include <boost/signals2.hpp>

#include "cinder/app/AppBasic.h"
#include "cinder/Url.h"
#include "cinder/Utilities.h"

class TcpShapeClient
{
public:
	TcpShapeClient();
	virtual ~TcpShapeClient();

	void setDelimiter(const std::string &delimiter);
	virtual void update();

	virtual void connect(const std::string &ip, unsigned short port);
	void connect(boost::asio::ip::tcp::endpoint& endpoint);
	virtual void disconnect();
	
public:
	boost::signals2::signal<void(const boost::asio::ip::tcp::endpoint&)>	sConnected;
	boost::signals2::signal<void(const boost::asio::ip::tcp::endpoint&)>	sDisconnected;
	boost::signals2::signal<void(const std::string&)>						sMessage;

private:
	virtual void read();
	virtual void close();

	// callbacks
	virtual void handle_connect(const boost::system::error_code& error);
	virtual void handle_read(const boost::system::error_code& error);
	virtual void do_close();

	virtual void do_reconnect(const boost::system::error_code& error);

private:
	bool							isConnected;
	bool							isClosing;
	boost::asio::ip::tcp::endpoint	endPoint;
	boost::asio::io_service			ioService;
	boost::asio::ip::tcp::socket	socket;
	boost::asio::streambuf			buffer;
	boost::asio::deadline_timer		reconnectTimer;
	std::string						delimiter;
};

