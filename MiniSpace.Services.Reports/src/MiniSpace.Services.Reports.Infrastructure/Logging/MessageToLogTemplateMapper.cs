using Convey.Logging.CQRS;
using MiniSpace.Services.Reports.Application.Commands;
using MiniSpace.Services.Reports.Application.Events.External;

namespace MiniSpace.Services.Reports.Infrastructure.Logging
{
    internal sealed class MessageToLogTemplateMapper : IMessageToLogTemplateMapper
    {
        private static IReadOnlyDictionary<Type, HandlerLogTemplate> MessageTemplates 
            => new Dictionary<Type, HandlerLogTemplate>
            {
                {
                    typeof(CreateRootOrganization),  new HandlerLogTemplate
                    {
                        After = "Created a new root organization with id: {OrganizationId}."
                    }
                },
                {
                    typeof(CreateOrganization),  new HandlerLogTemplate
                    {
                        After = "Added a new child organization with id: {OrganizationId} for parent with id: {ParentId}."
                    }
                },
                {
                    typeof(AddOrganizerToOrganization), new HandlerLogTemplate
                    {
                        After = "Added an organizer with id: {OrganizerId} to the organization with id: {OrganizationId}."
                    }
                },
                {
                    typeof(RemoveOrganizerFromOrganization), new HandlerLogTemplate
                    {
                        After = "Removed an organizer with id: {OrganizerId} from the organization with id: {OrganizationId}."
                    }
                },
                {
                    typeof(OrganizerRightsGranted), new HandlerLogTemplate
                    {
                        After = "Created an organizer with id: {UserId}."
                    }
                },
                {
                    typeof(OrganizerRightsRevoked), new HandlerLogTemplate
                    {
                        After = "Deleted an organizer with id: {UserId}."
                    }
                }
            };
        
        public HandlerLogTemplate Map<TMessage>(TMessage message) where TMessage : class
        {
            var key = message.GetType();
            return MessageTemplates.TryGetValue(key, out var template) ? template : null;
        }
    }
}
