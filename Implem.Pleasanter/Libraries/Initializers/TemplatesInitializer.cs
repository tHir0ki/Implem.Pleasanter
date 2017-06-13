﻿using Implem.DefinitionAccessor;
using Implem.Libraries.DataSources.SqlServer;
using Implem.Pleasanter.Libraries.DataSources;
using System.Linq;
namespace Implem.Pleasanter.Libraries.Initializers
{
    public class TemplatesInitializer
    {
        public static void Initialize()
        {
            Def.SqlIoByAdmin(statements: new SqlStatement(commandText: Def.Sql.TruncateTemplate))
                .ExecuteNonQuery();
            Def.TemplateDefinitionCollection.OrderBy(o => o.Order).ForEach(templateDefinition =>
                Rds.ExecuteNonQuery(statements: Rds.InsertTemplates(param: Rds.TemplatesParam()
                    .Title(templateDefinition.Title)
                    .Standard(templateDefinition.Standard)
                    .Body(templateDefinition.Body)
                    .Tags(templateDefinition.Tags)
                    .SiteSettingsTemplate(templateDefinition.SiteSettingsTemplate))));
        }
    }
}