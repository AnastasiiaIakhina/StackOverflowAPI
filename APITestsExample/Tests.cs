using RestSharp;
using NUnit.Framework;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace StackOverflowAPI
{
    [TestFixture]
    class StackOverflowTests
    {
        string baseUri = "https://api.stackexchange.com/2.2/";
        string questions = "questions?order=desc&sort=activity&tagged=c%23%3B.NET%3BSelenium&site=stackoverflow";
        string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "result.txt");

        [Test]
        public void TestTask()
        {
            string json = GetSomething(questions);
            RootObject userObj = JsonConvert.DeserializeObject<RootObject>(json);
            List<Question> listOfQuestions = new List<Question>();
            List<string> needed_users = new List<string>();
            for (int i = 0; i < userObj.items.Count; i++)
            {
                listOfQuestions.Add(new Question() { user_id = userObj.items[i].owner.user_id, question = userObj.items[i].title });
                needed_users.Add(listOfQuestions[i].user_id.ToString() + ";");
            }
            string needed_users_url = string.Join("", needed_users);
            string endpointUsers = "users/" + needed_users_url.TrimEnd(';') + "?order=desc&sort=reputation&site=stackoverflow";
            string jsonUsers = GetSomething(endpointUsers);
            RootObject1 userObj1 = JsonConvert.DeserializeObject<RootObject1>(jsonUsers);
            List<Badge> listOfBadges = new List<Badge>();
            for (int i = 0; i < userObj1.items.Count; i++)
            {
                listOfBadges.Add(new Badge() { userId = userObj1.items[i].user_id, badgeSum = userObj1.items[i].badge_counts.bronze + userObj1.items[i].badge_counts.silver + userObj1.items[i].badge_counts.gold });
            }
            listOfBadges.Sort();
            listOfBadges.Reverse();
            var sorted =   from question in listOfQuestions
                           from badge in listOfBadges
                           where question.user_id == badge.userId
                           orderby badge.badgeSum descending
                           select new { badgeSum = badge.badgeSum, title = question.question };
            File.WriteAllText(destPath, string.Empty);
            foreach (var item in sorted)
          {
                File.AppendAllText(destPath, item.badgeSum.ToString() + "  " + item.title + "\n");
            }
        }

        private string GetSomething(string endpoint)
        {
            var client = new RestClient(baseUri);
            var request = new RestRequest(endpoint, Method.GET);
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            string json = response.Content;
            return json;
        }

    }
}
