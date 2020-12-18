// This code was generated by Hypar.
// Edits to this code will be overwritten the next time you run 'hypar init'.
// DO NOT EDIT THIS FILE.

using Elements;
using Elements.GeoJSON;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements.Properties;
using Elements.Validators;
using Elements.Serialization.JSON;
using Hypar.Functions;
using Hypar.Functions.Execution;
using Hypar.Functions.Execution.AWS;
using System;
using System.Collections.Generic;
using System.Linq;
using Line = Elements.Geometry.Line;
using Polygon = Elements.Geometry.Polygon;

namespace PlusShapedEnvelope
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v12.0.0.0)")]
    
    public  class PlusShapedEnvelopeInputs : S3Args
    
    {
        [Newtonsoft.Json.JsonConstructor]
        
        public PlusShapedEnvelopeInputs(Vector3 @plusCenterLocation, double @siteSetback, double @envelopeHeight, double @rotation, double @envelopeWidth, string bucketName, string uploadsBucket, Dictionary<string, string> modelInputKeys, string gltfKey, string elementsKey, string ifcKey):
        base(bucketName, uploadsBucket, modelInputKeys, gltfKey, elementsKey, ifcKey)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<PlusShapedEnvelopeInputs>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @plusCenterLocation, @siteSetback, @envelopeHeight, @rotation, @envelopeWidth});
            }
        
            this.PlusCenterLocation = @plusCenterLocation;
            this.SiteSetback = @siteSetback;
            this.EnvelopeHeight = @envelopeHeight;
            this.Rotation = @rotation;
            this.EnvelopeWidth = @envelopeWidth;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        /// <summary>A 3D vector.</summary>
        [Newtonsoft.Json.JsonProperty("Plus Center Location", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Vector3 PlusCenterLocation { get; set; }
    
        /// <summary>How far back from the site boundary.</summary>
        [Newtonsoft.Json.JsonProperty("Site Setback", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1D, 10D)]
        public double SiteSetback { get; set; }
    
        /// <summary>How tall should the envelope be?</summary>
        [Newtonsoft.Json.JsonProperty("Envelope Height", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(4D, 300D)]
        public double EnvelopeHeight { get; set; }
    
        /// <summary>The angle of rotation of the cross relative to the world XY Axes</summary>
        [Newtonsoft.Json.JsonProperty("Rotation", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0D, 90D)]
        public double Rotation { get; set; }
    
        /// <summary>How wide should each leg of the envelope be?</summary>
        [Newtonsoft.Json.JsonProperty("Envelope Width", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(10D, 30D)]
        public double EnvelopeWidth { get; set; }
    
    
    }
}