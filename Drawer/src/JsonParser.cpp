#include "JsonParser.h"
#include "cinder/Json.h"
#include "Constants.h"

JsonParser::JsonParser()
{
}


JsonParser::~JsonParser()
{
}

bool JsonParser::parseFromTestFile(std::list<Shape*>& shapeList)
{
	std::string fileContent;

	try
	{
		fileContent = loadString(loadAsset(TEST_FILE_NAME));
	}
	catch(Exception ex)
	{
		console() << "JsonParser::parseFromFile: Exception when parsing JSON-Values: " << ex.what();
		return false;
	}

	return parse(fileContent, shapeList);
}

bool JsonParser::parse(const std::string& jsonString, std::list<Shape*>& shapeList)
{
	for(auto it = shapeList.begin(); it != shapeList.end(); ++it)
		delete *it;
	shapeList.clear();

	try
	{
		JsonTree doc(jsonString);
		std::list<JsonTree> shapes = doc.getChildren();

		for(JsonTree::ConstIter shape = shapes.begin(); shape != shapes.end(); ++shape)
		{
			std::list<JsonTree> shapeValues = shape->getChildren();
			Shape* newShape = Shape::create(shape->getChild(KEY_TYPE).getValue());
			if(!newShape->parseValuesFromJSON(shape))
				return false;
			shapeList.push_back(newShape);
		}
	}
	catch(Exception ex)
	{
		console() << "JsonParser::parse: Exception when parsing JSON-Values: " << ex.what();
		return false;
	}

	return true;
}

Vec2i JsonParser::convertToVector(const std::string& value)
{
	unsigned commaPos = value.find(',');
	std::string xPos = value.substr(0, commaPos);
	std::string yPos = value.substr(commaPos + 1);
	return Vec2i(atoi(xPos.c_str()), atoi(yPos.c_str()));
}