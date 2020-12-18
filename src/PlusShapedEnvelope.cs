using Elements;
using Elements.Geometry;
using Elements.Geometry.Solids;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusShapedEnvelope
{
    public static class PlusShapedEnvelope
    {
        /// <summary>
        /// The PlusShapedEnvelope function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A PlusShapedEnvelopeOutputs instance containing computed results and the model with any new elements.</returns>
        public static PlusShapedEnvelopeOutputs Execute(Dictionary<string, Model> inputModels, PlusShapedEnvelopeInputs input)
        {
            var outputs = new PlusShapedEnvelopeOutputs();
            var rotation = new Transform(Vector3.Origin, input.Rotation).Concatenated(new Transform(input.PlusCenterLocation));
            var line1 = new Line(new Vector3(-300, 0, 0), new Vector3(300, 0, 0)).ToPolyline().TransformedPolyline(rotation);
            var line2 = new Line(new Vector3(0, -300, 0), new Vector3(0, 300, 0)).ToPolyline().TransformedPolyline(rotation);
            var offset1 = line1.Offset(input.EnvelopeWidth / 2, EndType.Butt);
            var offset2 = line2.Offset(input.EnvelopeWidth / 2, EndType.Butt);
            var site = inputModels["Site"].AllElementsOfType<Site>().First();
            var siteBoundary = site.Perimeter.Offset(-input.SiteSetback);
            var joinedCross = Polygon.UnionAll(offset1.Union(offset2).ToList());
            var intersection = Polygon.Intersection(siteBoundary, joinedCross);
            var solidOps = new List<SolidOperation>();
            solidOps.AddRange(intersection.Select(b => new Extrude(b, input.EnvelopeHeight, Vector3.ZAxis, false)));
            var representation = new Representation(solidOps);
            outputs.Model.AddElements(intersection.Select(b => new Envelope(b, 0, input.EnvelopeHeight, Vector3.ZAxis, 0, new Transform(), BuiltInMaterials.Mass, representation, false, Guid.NewGuid(), null)));

            return outputs;
        }
    }
}