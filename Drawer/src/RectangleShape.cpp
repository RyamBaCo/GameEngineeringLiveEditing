#include "RectangleShape.h"
#include "JsonParser.h"

RectangleShape::RectangleShape()
{
}

RectangleShape::RectangleShape(const Vec2i edgePoints[AMOUNT_EDGE_POINTS])
{
	for(int i = 0; i < AMOUNT_EDGE_POINTS; ++i)
		this->edgePoints[i] = edgePoints[i];
}


RectangleShape::~RectangleShape()
{
}

bool RectangleShape::parseValuesFromJSON(const JsonTree::ConstIter& values)
{
	try
	{
		std::list<JsonTree> pointValues = values->getChild(KEY_POINTS).getChildren();
		int index = 0;
		for(JsonTree::ConstIter pointValue = pointValues.begin(); pointValue != pointValues.end(); ++pointValue)
			edgePoints[index++] = JsonParser::convertToVector(pointValue->getValue());
	}
	catch(Exception ex)
	{
		console() << "RectangleShape::parseValuesFromJSON: Exception when parsing JSON-Values: " << ex.what();
		return false;
	}

	return true;
}

void RectangleShape::draw()
{
	for(int i = 0; i < AMOUNT_EDGE_POINTS - 1; ++i)
		gl::drawLine(edgePoints[i], edgePoints[i + 1]);
	gl::drawLine(edgePoints[AMOUNT_EDGE_POINTS - 1], edgePoints[0]);
}