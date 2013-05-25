#pragma once
#include "json/json.h"
#include "cinder/app/AppBasic.h"
#include "Shape.h"

using namespace ci;
using namespace ci::app;

class JsonParser
{
public:
	JsonParser();
	~JsonParser();

	static bool parse(const std::string& fileName, std::list<Shape*>& shapeList);

private:
	static Vec2i convertToVector(const std::string& value);
};

