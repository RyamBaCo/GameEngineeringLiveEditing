#pragma once
#include "cinder/app/AppBasic.h"
#include "cinder/Json.h"
#include "Constants.h"

using namespace ci;
using namespace ci::app;

class Shape
{
public:
	virtual void draw() = 0;
	virtual bool parseValuesFromJSON(const JsonTree::ConstIter& values) = 0;

	static Shape* create(const std::string& type);
};