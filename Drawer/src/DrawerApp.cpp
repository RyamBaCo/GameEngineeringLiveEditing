#include "cinder/app/AppBasic.h"
#include "cinder/gl/gl.h"
#include "JsonParser.h"
#include "Shape.h"

using namespace ci;
using namespace ci::app;

class DrawerApp : public AppBasic 
{
public:
	void setup();
	void mouseDown( MouseEvent event );	
	void update();
	void draw();

private:
	std::list<Shape*> shapes;
};

void DrawerApp::setup()
{
	JsonParser::parse("test.json", shapes);
}

void DrawerApp::mouseDown( MouseEvent event )
{
}

void DrawerApp::update()
{
}

void DrawerApp::draw()
{
	gl::clear(Color(0, 0, 0));

	for(auto it = shapes.begin(); it != shapes.end(); ++it)
		(*it)->draw();
}

CINDER_APP_BASIC( DrawerApp, RendererGl )
