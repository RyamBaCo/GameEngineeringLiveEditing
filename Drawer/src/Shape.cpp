#include "Shape.h"
#include "RectangleShape.h"
#include "CircleShape.h"

Shape* Shape::create(const ShapeValues& values)
{
	if(values.type == TYPE_RECTANGLE)
		return new RectangleShape(values.edgePoints);
	else if(values.type == TYPE_CIRCLE)
		return new CircleShape(values.radius, values.centerPoint);

	return 0;
}