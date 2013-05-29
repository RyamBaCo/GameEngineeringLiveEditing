#include "CircleShape.h"
#include "JsonParser.h"

CircleShape::CircleShape()
	:	radius(0),
		centerPoint(Vec2i(-1, -1))
{
}

CircleShape::CircleShape(const int radius, const Vec2i& centerPoint)
	:	radius(radius),
		centerPoint(centerPoint)
{
}

CircleShape::~CircleShape()
{
}

bool CircleShape::parseValuesFromJSON(const JsonTree::ConstIter& values)
{
	try
	{
		radius = values->getChild(KEY_RADIUS).getValue<int>();
		centerPoint = JsonParser::convertToVector(values->getChild(KEY_CENTER).getValue());
	}
	catch(Exception ex)
	{
		console() << "CircleShape::parseValuesFromJSON: Exception when parsing JSON-Values: " << ex.what();
		return false;
	}
	
	return true;
}

void CircleShape::draw()
{
	gl::drawSolidCircle(centerPoint, radius);
}
