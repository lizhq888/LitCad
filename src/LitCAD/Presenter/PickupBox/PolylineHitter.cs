using System;
using System.Collections.Generic;

using LitCAD.DatabaseServices;
using LitCAD.UI;

namespace LitCAD.UI
{
    internal class PolylineHitter : EntityHitter
    {
        internal override bool Hit(PickupBox pkbox, Entity entity)
        {
            Polyline polyline = entity as Polyline;
            if (polyline == null)
                return false;

            Bounding pkBounding = pkbox.reservedBounding;
            var lines = polyline.ToLines();
            foreach (var line in lines)
            {
                if (LineHitter.BoundingIntersectWithLine(pkBounding, line.litMathLine))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
