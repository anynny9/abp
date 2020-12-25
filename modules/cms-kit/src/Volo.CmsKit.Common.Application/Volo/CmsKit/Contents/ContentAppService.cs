﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.CmsKit.Common.Application.Contracts.Volo.CmsKit.Contents;

namespace Volo.CmsKit.Contents
{
    public class ContentAppService : CmsKitAppServiceBase, IContentAppService
    {
        protected readonly IContentRepository ContentRepository;

        public ContentAppService(IContentRepository contentRepository)
        {
            ContentRepository = contentRepository;
        }

        public virtual async Task<ContentDto> GetAsync(GetContentInput input)
        {
            var entity = await ContentRepository.FindAsync(
                input.EntityType,
                input.EntityId,
                CurrentTenant.Id);

            return ObjectMapper.Map<Content, ContentDto>(entity);
        }
    }
}