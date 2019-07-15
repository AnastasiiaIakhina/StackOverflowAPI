using System;
using System.Collections.Generic;

namespace StackOverflowAPI
{
public class Owner
{
    public int reputation { get; set; }
    public int user_id { get; set; }
    public string user_type { get; set; }
    public string profile_image { get; set; }
    public string display_name { get; set; }
    public string link { get; set; }
    public int? accept_rate { get; set; }
}

public class Item
{
    public List<string> tags { get; set; }
    public Owner owner { get; set; }
    public bool is_answered { get; set; }
    public int view_count { get; set; }
    public int accepted_answer_id { get; set; }
    public int answer_count { get; set; }
    public int score { get; set; }
    public int last_activity_date { get; set; }
    public int creation_date { get; set; }
    public int last_edit_date { get; set; }
    public int question_id { get; set; }
    public string link { get; set; }
    public string title { get; set; }
    public int? closed_date { get; set; }
    public string closed_reason { get; set; }
}

public class RootObject
{
    public List<Item> items { get; set; }
    public bool has_more { get; set; }
    public int quota_max { get; set; }
    public int quota_remaining { get; set; }
}
    public class Question
    {
        public int user_id { get; set; }
        public string question { get; set; }
    }

    public class BadgeCounts
    {
        public int bronze { get; set; }
        public int silver { get; set; }
        public int gold { get; set; }
    }

    public class User
    {
        public BadgeCounts badge_counts { get; set; }
        public int account_id { get; set; }
        public bool is_employee { get; set; }
        public int last_modified_date { get; set; }
        public int last_access_date { get; set; }
        public int reputation_change_year { get; set; }
        public int reputation_change_quarter { get; set; }
        public int reputation_change_month { get; set; }
        public int reputation_change_week { get; set; }
        public int reputation_change_day { get; set; }
        public int reputation { get; set; }
        public int creation_date { get; set; }
        public string user_type { get; set; }
        public int user_id { get; set; }
        public int accept_rate { get; set; }
        public string location { get; set; }
        public string website_url { get; set; }
        public string link { get; set; }
        public string profile_image { get; set; }
        public string display_name { get; set; }
    }

    public class RootObject1
    {
        public List<User> items { get; set; }
        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }
    }
    public class Badge : IComparable<Badge>
    {
        public int userId { get; set; }
        public int badgeSum { get; set; }

        public int CompareTo(Badge compareBadge)
        {
            // A null value means that this object is greater.
            if (compareBadge == null)
                return 1;
            else
                return this.badgeSum.CompareTo(compareBadge.badgeSum);
        }
    }
}