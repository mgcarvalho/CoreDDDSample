using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.ViewModel
{

    public class PostView
    {
        /// <summary>
        /// Gets or sets the unique identify
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the subject of post
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the text of post
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the date of created
        /// </summary>
        public DateTime Create { get; set; }

        /// <summary>
        /// Gets or sets the owner name
        /// </summary>
        public string PosterName { get; set; }

        /// <summary>
        /// Gets or sets the owner email
        /// </summary>
        public string PosterEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the post is open.
        /// </summary>
        public bool Open { get; set; }
    }
}
