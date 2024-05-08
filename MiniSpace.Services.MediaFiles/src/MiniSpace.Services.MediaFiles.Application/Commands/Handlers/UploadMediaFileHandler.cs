﻿using Convey.CQRS.Commands;
using MiniSpace.Services.MediaFiles.Application.Events;
using MiniSpace.Services.MediaFiles.Application.Exceptions;
using MiniSpace.Services.MediaFiles.Application.Services;
using MiniSpace.Services.MediaFiles.Core.Entities;
using MiniSpace.Services.MediaFiles.Core.Repositories;

namespace MiniSpace.Services.MediaFiles.Application.Commands.Handlers
{
    public class UploadMediaFileHandler: ICommandHandler<UploadMediaFile>
    {
        private readonly IFileSourceInfoRepository _fileSourceInfoRepository;
        private readonly IGridFSService _gridFSService;
        private readonly IMessageBroker _messageBroker;
        
        public UploadMediaFileHandler(IFileSourceInfoRepository fileSourceInfoRepository, IGridFSService gridFSService,
            IMessageBroker messageBroker)
        {
            _fileSourceInfoRepository = fileSourceInfoRepository;
            _gridFSService = gridFSService;
            _messageBroker = messageBroker;
        }
        
        public async Task HandleAsync(UploadMediaFile command, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse(command.SourceType, out ContextType sourceType))
            {
                throw new InvalidContextTypeException(command.SourceType);
            }
            byte[] bytes = Convert.FromBase64String(command.Base64Content);
            var stream = new MemoryStream(bytes);

            var objectId = await _gridFSService.UploadFileAsync(command.FileName, stream);
            var fileSourceInfo = new FileSourceInfo(command.MediaFileId, command.SourceId, sourceType, objectId);
            await _fileSourceInfoRepository.AddAsync(fileSourceInfo);
            await _messageBroker.PublishAsync(new MediaFileUploaded(command.MediaFileId, command.FileName));
        }
    }
}