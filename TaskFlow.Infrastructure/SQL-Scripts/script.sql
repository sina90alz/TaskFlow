CREATE TABLE Permissions (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Code NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255) NULL
);

CREATE TABLE UserPermissions (
    UserId UNIQUEIDENTIFIER NOT NULL,
    PermissionId UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT PK_UserPermissions PRIMARY KEY (UserId, PermissionId),

    CONSTRAINT FK_UserPermissions_Permissions
        FOREIGN KEY (PermissionId)
        REFERENCES Permissions(Id)
        ON DELETE CASCADE
);

CREATE INDEX IX_UserPermissions_UserId
ON UserPermissions(UserId);

CREATE INDEX IX_UserPermissions_PermissionId
ON UserPermissions(PermissionId);

INSERT INTO Permissions (Id, Code, Description)
VALUES
(NEWID(), 'tasks.create', 'Create a task'),
(NEWID(), 'tasks.update', 'Update a task'),
(NEWID(), 'tasks.delete', 'Delete a task');


DECLARE @UserId UNIQUEIDENTIFIER = 'PUT-USER-GUID-HERE';

INSERT INTO UserPermissions (UserId, PermissionId)
SELECT @UserId, Id
FROM Permissions
WHERE Code IN ('tasks.create', 'tasks.update');