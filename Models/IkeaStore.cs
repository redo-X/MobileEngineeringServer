using Newtonsoft.Json;

public class IkeaStore
{
    [JsonProperty("store_id")]
    public int Id { get; set; }
    
     [JsonProperty("store_name")]
    public string DisplayName { get; set; }

}