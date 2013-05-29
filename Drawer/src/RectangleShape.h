#pragma once
#include "Shape.h"

class RectangleShape : public Shape
{
public:
	RectangleShape();
	RectangleShape(const Vec2i edgePoints[AMOUNT_EDGE_POINTS]);
	~RectangleShape();

	void draw();
	bool parseValuesFromJSON(const JsonTree::ConstIter& values);

private:
	Vec2i edgePoints[AMOUNT_EDGE_POINTS];
};

