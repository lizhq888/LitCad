using System;

using LitCAD.ApplicationServices;
using LitCAD.DatabaseServices;

namespace LitCAD
{
    internal class PolylineRS : EntityRS
    {
        internal override bool Cross(Bounding selectBound, Entity entity)
        {
            Polyline polyline = entity as Polyline;
            if (polyline == null)
            {
                return false;
            }

            Bounding polylineBound = polyline.bounding;
            if (selectBound.Contains(polylineBound))
            {
                return true;
            }

            var lines = polyline.ToLines();
            foreach (var line in lines)
            {
                if (EntityRSMgr.Instance.type2EntityRS[line.GetType()].Cross(selectBound, line))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
