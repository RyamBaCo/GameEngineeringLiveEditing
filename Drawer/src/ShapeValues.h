#pragma once
#include "cinder/app/AppBasic.h"
using namespace ci;

struct ShapeValues
{
	std::string name;
	std::string type;
	Vec2i edgePoints[4];
	Vec2i centerPoint;
	int radius;
};