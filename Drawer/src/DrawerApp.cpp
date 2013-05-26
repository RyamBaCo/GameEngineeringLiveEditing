#include <boost/thread/mutex.hpp>

#include "cinder/app/AppBasic.h"
#include "cinder/gl/gl.h"
#include "JsonParser.h"
#include "Shape.h"
#include "TcpShapeClient.h"

using namespace ci;
using namespace ci::app;

class DrawerApp : public AppBasic 
{
public:
	void setup();
	void shutdown();
	void update();
	void draw();

	void onConnected(const boost::asio::ip::tcp::endpoint& endPoint);
	void onDisconnected(const boost::asio::ip::tcp::endpoint& endPoint);
	void onMessage(const std::string& message);

private:
	std::list<Shape*>	shapes;
	TcpShapeClient		tcpClient;
	std::string			receivedJSON;

	boost::mutex		jsonMutex;
};

void DrawerApp::setup()
{
	receivedJSON = "";

	tcpClient.sConnected.connect(boost::bind(&DrawerApp::onConnected, this, boost::arg<1>::arg()));
	tcpClient.sDisconnected.connect(boost::bind(&DrawerApp::onDisconnected, this, boost::arg<1>::arg()));
	tcpClient.sMessage.connect(boost::bind(&DrawerApp::onMessage, this, boost::arg<1>::arg()));

	tcpClient.setDelimiter("\r\n");
	tcpClient.connect("127.0.0.1", 3000);
}

void DrawerApp::shutdown()
{
	for(auto it = shapes.begin(); it != shapes.end(); ++it)
		delete *it;
	shapes.clear();
}

void DrawerApp::update()
{
	tcpClient.update();

	if(receivedJSON != "")
	{
		boost::mutex::scoped_lock(jsonMutex);
		JsonParser::parse(receivedJSON, shapes);
		receivedJSON = "";
	}
}

void DrawerApp::draw()
{
	gl::clear(Color(0, 0, 0));

	for(auto it = shapes.begin(); it != shapes.end(); ++it)
		(*it)->draw();
}

void DrawerApp::onConnected(const boost::asio::ip::tcp::endpoint& endPoint)
{
	console() << "Connected to: " << endPoint.address().to_string() << std::endl;
}

void DrawerApp::onDisconnected(const boost::asio::ip::tcp::endpoint& endPoint)
{
	console() << "Disconnected from: " << endPoint.address().to_string() << std::endl;
	console() << "Trying to reconnect in 5 seconds." << std::endl;
}

void DrawerApp::onMessage(const std::string &message)
{
	boost::mutex::scoped_lock(jsonMutex);
	receivedJSON = message;
}

CINDER_APP_BASIC( DrawerApp, RendererGl )
