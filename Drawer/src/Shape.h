#pragma once
#include "cinder/app/AppBasic.h"
#include "Constants.h"
#include "ShapeValues.h"

using namespace ci;
using namespace ci::app;

class Shape
{
public:
	virtual void draw() = 0;
	static Shape* create(const ShapeValues& values);
};