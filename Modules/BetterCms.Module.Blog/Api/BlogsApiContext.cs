﻿using System;
using System.Linq;

using Autofac;

using BetterCms.Core.Api.DataContracts;
using BetterCms.Core.Api.Extensions;
using BetterCms.Core.DataAccess;
using BetterCms.Core.DataContracts.Enums;
using BetterCms.Core.Exceptions.Api;
using BetterCms.Module.Blog.Api.DataContracts;
using BetterCms.Module.Blog.Api.Events;
using BetterCms.Module.Blog.Models;

using NHibernate.Linq;

// ReSharper disable CheckNamespace
namespace BetterCms.Api
// ReSharper restore CheckNamespace
{
    public class BlogsApiContext : DataApiContext
    {
        private static readonly BlogsApiEvents events;

        /// <summary>
        /// Initializes the <see cref="BlogsApiContext" /> class.
        /// </summary>
        static BlogsApiContext()
        {
            events = new BlogsApiEvents();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogsApiContext" /> class.
        /// </summary>
        /// <param name="lifetimeScope">The lifetime scope.</param>
        /// <param name="repository">The repository.</param>
        public BlogsApiContext(ILifetimeScope lifetimeScope, IRepository repository = null)
            : base(lifetimeScope, repository)
        {
        }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public new static BlogsApiEvents Events
        {
            get
            {
                return events;
            }
        }

        /// <summary>
        /// Gets the list of blog entities.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The list of blog entities
        /// </returns>
        /// <exception cref="CmsApiException"></exception>
        public DataListResponse<BlogPost> GetBlogPosts(GetBlogPostsRequest request)
        {
            try
            {
                var query = Repository
                    .AsQueryable<BlogPost>()
                    .ApplyFilters(request);

                if (!request.IncludeUnpublished)
                {
                    query = query.Where(b => b.Status == PageStatus.Published);
                }

                if (!request.IncludePrivate)
                {
                    query = query.Where(b => b.IsPublic);
                }

                var totalCount = query.ToRowCountFutureValue(request);

                query = query
                    .AddOrderAndPaging(request)
                    .Fetch(b => b.Author);

                return query.ToDataListResponse(totalCount);
            }
            catch (Exception inner)
            {
                const string message = "Failed to get blog posts list.";
                Logger.Error(message, inner);

                throw new CmsApiException(message, inner);
            }
        }

        /// <summary>
        /// Gets the list of author entities.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The list of tag entities
        /// </returns>
        /// <exception cref="CmsApiException"></exception>
        public DataListResponse<Author> GetAuthors(GetAuthorsRequest request)
        {
            try
            {
                var query = Repository
                    .AsQueryable<Author>()
                    .ApplyFilters(request);

                var totalCount = query.ToRowCountFutureValue(request);

                query = query
                    .AddOrderAndPaging(request)
                    .Fetch(a => a.Image);

                return query.ToDataListResponse(totalCount);

            }
            catch (Exception inner)
            {
                const string message = "Failed to get authors list.";
                Logger.Error(message, inner);

                throw new CmsApiException(message, inner);
            }
        }
    }
}