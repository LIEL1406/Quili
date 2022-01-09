using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace spoonacular.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class InlineResponse20042Measures {
    /// <summary>
    /// Gets or Sets Original
    /// </summary>
    [DataMember(Name="original", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "original")]
    public RecipesParseIngredientsNutritionWeightPerServing Original { get; set; }

    /// <summary>
    /// Gets or Sets Metric
    /// </summary>
    [DataMember(Name="metric", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "metric")]
    public RecipesParseIngredientsNutritionWeightPerServing Metric { get; set; }

    /// <summary>
    /// Gets or Sets Us
    /// </summary>
    [DataMember(Name="us", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "us")]
    public RecipesParseIngredientsNutritionWeightPerServing Us { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class InlineResponse20042Measures {\n");
      sb.Append("  Original: ").Append(Original).Append("\n");
      sb.Append("  Metric: ").Append(Metric).Append("\n");
      sb.Append("  Us: ").Append(Us).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
