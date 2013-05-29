#pragma once
#include "Shape.h"

class CircleShape :
	public Shape
{
public:
	CircleShape();
	CircleShape(const int radius, const Vec2i& centerPoint);
	~CircleShape();

	void draw();
	bool parseValuesFromJSON(const JsonTree::ConstIter& values);

private:
	int radius;
	Vec2i centerPoint;
};

