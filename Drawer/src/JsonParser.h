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

	static bool parseFromTestFile(std::list<Shape*>& shapeList);
	static bool parse(const std::string& jsonString, std::list<Shape*>& shapeList);
	static Vec2i convertToVector(const std::string& value);
};

