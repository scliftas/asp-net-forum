﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QAForum.Models
{
    public class SQLForumRepository : IForumRepository
    {
        ForumEntities forumDB = new ForumEntities();

        IEnumerable<Forum> IForumRepository.GetAllForums()
        {
            return forumDB.Forums.ToList();
        }

        IEnumerable<Thread> IForumRepository.GetAllThreads()
        {
            return forumDB.Threads.ToList();
        }

        IEnumerable<Post> IForumRepository.GetAllPosts()
        {
            return forumDB.Posts.ToList();
        }

        Forum IForumRepository.GetForumByID(int ForumID)
        {
            return forumDB.Forums.Single(f => f.ForumID == ForumID);
        }

        Thread IForumRepository.GetThreadByID(int ThreadID)
        {
            return forumDB.Threads.Single(t => t.ThreadID == ThreadID);
        }

        Post IForumRepository.GetPostByID(int PostID)
        {
            return forumDB.Posts.Single(p => p.PostID == PostID);
        }

        IEnumerable<Thread> IForumRepository.GetThreadsByForum(int ForumID)
        {
            return forumDB.Threads.Where(t => t.ForumID == ForumID).ToList();
        }

        IEnumerable<Post> IForumRepository.GetPostsByThread(int ThreadID)
        {
            return forumDB.Posts.Where(p => p.ThreadID == ThreadID).ToList();
        }

        void IForumRepository.AddForum(Forum forum)
        {
            forumDB.Forums.Add(forum);
            forumDB.SaveChanges();
        }

        void IForumRepository.AddThread(Thread thread)
        {
            forumDB.Threads.Add(thread);
            forumDB.SaveChanges();
        }

        void IForumRepository.AddPost(Post post)
        {
            forumDB.Posts.Add(post);
            forumDB.SaveChanges();
        }

        void IForumRepository.UpdateForum(Forum forum)
        {
            Forum tmpForum = forumDB.Forums.Single(f => f.ForumID == forum.ForumID);

            tmpForum.ForumTitle = forum.ForumTitle;

            forumDB.SaveChanges();
        }

        void IForumRepository.UpdateThread(Thread thread)
        {
            Thread tmpThread = forumDB.Threads.Single(t => t.ThreadID == thread.ThreadID);

            tmpThread.ForumID = thread.ForumID;
            tmpThread.OwnerID = thread.OwnerID;
            tmpThread.ThreadTitle = thread.ThreadTitle;

            forumDB.SaveChanges();
        }

        void IForumRepository.UpdatePost(Post post)
        {
            Post tmpPost = forumDB.Posts.Single(p => p.PostID == post.PostID);

            tmpPost.PostBody = post.PostBody;
            tmpPost.PostDateTime = post.PostDateTime;
            tmpPost.PostTitle = post.PostTitle;
            tmpPost.ThreadID = post.ThreadID;
            tmpPost.UserID = post.UserID;

            forumDB.SaveChanges();
        }

        void IForumRepository.DeleteForum(Forum forum)
        {
            forumDB.Forums.Remove(forum);
            forumDB.SaveChanges();
        }

        void IForumRepository.DeleteThread(Thread thread)
        {
            forumDB.Threads.Remove(thread);
            forumDB.SaveChanges();
        }

        void IForumRepository.DeletePost(Post post)
        {
            forumDB.Posts.Remove(post);
            forumDB.SaveChanges();
        }

    }
}