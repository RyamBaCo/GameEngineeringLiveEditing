#include "JsonParser.h"
#include "cinder/Json.h"
#include "Constants.h"
#include "ShapeValues.h"

JsonParser::JsonParser()
{
}


JsonParser::~JsonParser()
{
}

bool JsonParser::parse(const std::string& fileName, std::list<Shape*>& shapeList)
{
	for(auto it = shapeList.begin(); it != shapeList.end(); ++it)
		delete *it;
	shapeList.clear();

	JsonTree doc( loadFile( fs::path( getAppPath().generic_string() + fileName ) ) );
	std::list<JsonTree> shapes = doc.getChildren();

	for(JsonTree::ConstIter shape = shapes.begin(); shape != shapes.end(); ++shape)
	{
		std::list<JsonTree> shapeValues = shape->getChildren();
		ShapeValues values;

		for(JsonTree::ConstIter shapeValue = shapeValues.begin(); shapeValue != shapeValues.end(); ++shapeValue)
		{
			std::string key = shapeValue->getKey();
			if(key == KEY_NAME)
				values.name = shapeValue->getValue();
			else if(key == KEY_TYPE)
				values.type = shapeValue->getValue();
			else if(key == KEY_RADIUS)
				values.radius = atoi(shapeValue->getValue().c_str());
			else if(key == KEY_CENTER)
				values.centerPoint = convertToVector(shapeValue->getValue());
			else if(key == KEY_POINTS)
			{
				std::list<JsonTree> pointValues = shapeValue->getChildren();
				int index = 0;
				for(JsonTree::ConstIter pointValue = pointValues.begin(); pointValue != pointValues.end(); ++pointValue)
					values.edgePoints[index++] = convertToVector(pointValue->getValue());
			}
		}

		shapeList.push_back(Shape::create(values));
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