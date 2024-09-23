﻿using FluentMigrator;

namespace External.Persistence.Migrations;

[Migration(202409221940)]
public class Initial : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript($"{typeof(Initial).Namespace}.Scripts.{nameof(Initial)}.sql");
    }

    public override void Down()
    {
    }
}