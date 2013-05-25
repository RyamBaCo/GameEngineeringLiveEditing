#include "RectangleShape.h"


RectangleShape::RectangleShape(const Vec2i edgePoints[AMOUNT_EDGE_POINTS])
{
	for(int i = 0; i < AMOUNT_EDGE_POINTS; ++i)
		this->edgePoints[i] = edgePoints[i];
}


RectangleShape::~RectangleShape()
{
}

void RectangleShape::draw()
{
	for(int i = 0; i < AMOUNT_EDGE_POINTS - 1; ++i)
		gl::drawLine(edgePoints[i], edgePoints[i + 1]);
	gl::drawLine(edgePoints[AMOUNT_EDGE_POINTS - 1], edgePoints[0]);
}