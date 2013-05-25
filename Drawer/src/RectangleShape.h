#pragma once
#include "Shape.h"

class RectangleShape : public Shape
{
public:
	RectangleShape(const Vec2i edgePoints[AMOUNT_EDGE_POINTS]);
	~RectangleShape();

	void draw();

private:
	Vec2i edgePoints[AMOUNT_EDGE_POINTS];
};

