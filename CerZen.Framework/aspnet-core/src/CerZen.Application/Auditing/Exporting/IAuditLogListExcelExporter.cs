using System.Collections.Generic;
using CerZen.Auditing.Dto;
using CerZen.Dto;

namespace CerZen.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
