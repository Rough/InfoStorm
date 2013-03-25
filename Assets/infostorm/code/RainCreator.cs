using UnityEngine;
using System.Collections;
using System.Net;
using Newtonsoft.Json;


public class RainCreator : MonoBehaviour
	{
	// CLASS VARIABLES ========================
	public static string[] tweets;

	// MEMBER VARIABLES =======================
	public GameObject rainDrop;

	private float lastTwitterRefresh = -100.0f;
	
	// MONOBEHAVIOUR OVERRIDES ================
	void Update()
		{
		if (Time.time > lastTwitterRefresh + 60.0f)
			{
			// WEB REQUEST ============================================
			WebClient webClient = new WebClient();
			string buffer = webClient.DownloadString("http://search.twitter.com/search.json?q=%23" + InfoStormConfigGUI.hashTag);
			// DESERIALISATION ========================================
			TwitterSearch twitterSearch = JsonConvert.DeserializeObject<TwitterSearch>(buffer);
			tweets = new string[twitterSearch.results.Length];
			for (int i = 0; i < twitterSearch.results.Length; i++)
				{
				tweets[i] = twitterSearch.results[i].text;
				}
			// TIMER RESET ============================================
			lastTwitterRefresh = Time.time;
			}
		if (Random.Range(0, 1000) > 700)
			{
			Vector3 position = new Vector3(Random.Range(-35f, 20f), 10f, 20f);
			GameObject spawnedRainDrop = Instantiate(rainDrop, position, Quaternion.Euler(0f, 0f, -60f)) as GameObject;
			}
		}

	// INTERNAL CLASSES ===================================
	private class TwitterSearch
		{
		public string completed_in { get; set; }
		public string max_id { get; set; }
		public string max_id_str { get; set; }
		public string next_page { get; set; }
		public string page { get; set; }
		public string query { get; set; }
		public string refresh_url { get; set; }
		public Tweet[] results { get; set; }
		public string results_per_page { get; set; }
		public string since_id { get; set; }
		public string since_id_str { get; set; }
		}

	private class Tweet
		{
		public string created_at { get; set; }
		public string from_user { get; set; }
		public string from_user_id { get; set; }
		public string from_user_id_str { get; set; }
		public string from_user_name { get; set; }
		public dynamic geo { get; set; }
		public string id_str { get; set; }
		public string iso_language_code { get; set; }
		public MetaData metadata { get; set; }
		public string profile_image_url { get; set; }
		public string profile_image_url_https { get; set; }
		public string source { get; set; }
		public string text { get; set; }
		}
	private class MetaData
		{
		public string result_type { get; set; }
		}
	}
