using System.Collections.Generic;
using Abp;
using CerZen.Chat.Dto;
using CerZen.Dto;

namespace CerZen.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
