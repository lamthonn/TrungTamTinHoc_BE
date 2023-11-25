namespace TrungTamTinHoc_BE.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public int PostId { get; set; }
        public Post Post { get; set; }
       
    }
}
