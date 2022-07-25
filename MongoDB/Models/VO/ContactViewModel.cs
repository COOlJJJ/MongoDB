using System.Collections.Generic;

namespace MongoDB.VO
{
    public class ContactViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public IList<GroupViewModel> Groups { get; set; }
    }

    public class GroupViewModel
    {
        public int GroupId { get; set; }

        public string Name { get; set; }
    }
}
