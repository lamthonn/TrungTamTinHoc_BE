
namespace TrungTamTinHoc_BE.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string maHV { get; set; }
		public HocVien? HocVien { get; set; }
		public string Title { get; set; }
        public string PathImage { get; set; }
        public List<Comment> Comment { get; set; }
		public List<Like> Like { get; set; }

	}
}
