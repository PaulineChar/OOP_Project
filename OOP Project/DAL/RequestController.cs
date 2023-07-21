using DAL.Constants;
using DAL.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DAL
{
    public static class RequestController
    {
        //- matches according to: country, championship

        /*
            Get all the countries that participated in @param championship
            @param: string championship: "men" or "women"
         */
        private static async Task<Country[]> GetCountries(string championship)
        {
            var apiClient = new RestClient(ApiConstants.BASE_ENDPOINT + $"{championship}/teams");
            var apiResult = await apiClient.ExecuteAsync<Country[]>(new RestRequest());

            Country[] countries = JsonConvert.DeserializeObject<Country[]>(apiResult.Content);
            return countries;
        }

        /*
         * Get all matches in which the selected country/team participated
         * @param: string championship: "men" or "women"
         *          string fifaCode: Fifa Code of the selected country
         */
        private static async Task<Match[]> GetMatches(string championship, string fifaCode)
        {
            var apiClient = new RestClient(ApiConstants.BASE_ENDPOINT + $"{championship}/matches/country?fifa_code={fifaCode}");
            var apiResult = await apiClient.ExecuteAsync<Match[]>(new RestRequest());

            Match[] matches = JsonConvert.DeserializeObject<Match[]>(apiResult.Content);
            return matches;
        }

        public static Country[] GetJsonCountries(string championship)
        {
            string json = string.Join('\0', File.ReadAllLines(ApiConstants.JSON_FILES + $"{championship}/teams.json"));
            Country[] countries = JsonConvert.DeserializeObject<Country[]>(json)!;
            return countries;
        }

        public static Match[] GetJsonMatches(string championship, string fifaCode)
        {
            string json = string.Join('\0', File.ReadAllLines(ApiConstants.JSON_FILES + $"{championship}/matches.json"));
            Match[] allMatches = JsonConvert.DeserializeObject<Match[]>(json)!;
            Match[] matches = allMatches.Where(match => match.AwayTeamCode.FifaCode == fifaCode || match.HomeTeamCode.FifaCode == fifaCode).ToArray();
            return matches;
        }

        public static Task<Country[]> GetCountriesData(string championship) => GetCountries(championship);


        public static Task<Match[]> GetMatchesData(string championship, string fifaCode) => GetMatches(championship, fifaCode);

    }
}
