#include "CircleShape.h"


CircleShape::CircleShape(const int radius, const Vec2i& centerPoint)
	:	radius(radius),
		centerPoint(centerPoint)
{
}


CircleShape::~CircleShape()
{
}

void CircleShape::draw()
{
	gl::drawSolidCircle(centerPoint, radius);
}
