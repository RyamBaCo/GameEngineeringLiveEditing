#pragma once
#include "Shape.h"

class CircleShape :
	public Shape
{
public:
	CircleShape(const int radius, const Vec2i& centerPoint);
	~CircleShape();

	void draw();

private:
	int radius;
	Vec2i centerPoint;
};

