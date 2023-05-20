USE FlashCardBlazorApp;

--USE japanese-words-server;

INSERT INTO dbo.AspNetUsers(Id, UserName, NormalizedUserName, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, AccessFailedCount, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled) VALUES
('89e26fe7-69ee-4e83-a015-130edf3d6a69', 'admin@admin.com', 'ADMIN@ADMIN.COM', 1, 'AQAAAAEAACcQAAAAEHbUISQrifGLs6MKzzhaxJz3ktSkzEX8becxRB4Y2CUjisBuLwf13dqdmuYZLATZkA==', 'VN7O72AE53QFLV7XTSYMB6AX7OTHSALU', '668c2037-73ef-4f10-a6cd-331c2b28717c', 0, 0, 0, 0);

INSERT INTO dbo.AspNetUserClaims(UserId, ClaimType, ClaimValue) VALUES
('89e26fe7-69ee-4e83-a015-130edf3d6a69', 'AdminRole', 'admin');