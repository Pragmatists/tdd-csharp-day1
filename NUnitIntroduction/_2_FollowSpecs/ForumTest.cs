using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitIntroduction._2_FollowSpecs
{
    class ForumTest
    {
        [Test]
        public void ShouldBeEmptyAfterCreation()
        {
            // given

            // when
            var forum = CreateForum();

            // then
            Assert.IsEmpty(forum.AllPosts);
        }

        [Test]
        public void UserShouldBeAbleToAddANewPost()
        {
            // given
            var forum = CreateForum();
            var post = CreatePost();

            // when
            forum.Add(post);

            // then
            CollectionAssert.Contains(forum.AllPosts, post);
        }

        [Test]
        public void UserShouldBeAbleToEditAPost()
        {
            // given
            var postA = CreatePost("A");
            var forum = CreateForumWith(postA);
            var newPost = CreatePost("B");

            // when
            forum.Edit(postA, newPost);

            // then
            CollectionAssert.DoesNotContain(forum.AllPosts, postA);
            CollectionAssert.Contains(forum.AllPosts, newPost);
        }

        [Test]
        public void UserCanEditOnlyAPostInTheForum()
        {
            // given
            var postA = CreatePost("A");
            var forum = CreateForum();
            var newPost = CreatePost("B");
           
            // then
            Assert.Throws<ArgumentException>(() => forum.Edit(postA, newPost));
        }

        private Forum CreateForumWith(Post post)
        {
            var forum = CreateForum();
            forum.Add(post);
            return forum;
        }

        private Post CreatePost(string content = "Sample post content")
        {
            return new Post {Content = content};
        }

        private static Forum CreateForum()
        {
            return new Forum();
        }
    }

    internal class Forum
    {
        private readonly IList<Post> allPosts;

        public IList<Post> AllPosts
        {
            get { return allPosts; }
        }

        public void Add(Post post)
        {
        }

        public void Edit(Post postToBeReplaced, Post newPost)
        {
        }
    }

    internal class Post
    {
        public string Content { get; set; }
        public override string ToString()
        {
            return Content;
        }
    }
}
