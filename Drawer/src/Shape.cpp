#include "Shape.h"
#include "RectangleShape.h"
#include "CircleShape.h"

Shape* Shape::create(const std::string& type)
{
	if(type == TYPE_RECTANGLE)
		return new RectangleShape();
	else if(type == TYPE_CIRCLE)
		return new CircleShape();

	return 0;
}