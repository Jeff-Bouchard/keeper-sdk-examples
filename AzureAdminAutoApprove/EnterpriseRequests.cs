﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using KeeperSecurity.Commands;

namespace AzureAdminAutoApprove
{
    [DataContract]
    public class EnterpriseDataCommand : AuthenticatedCommand
    {
        public EnterpriseDataCommand() : base("get_enterprise_data") { }

        [DataMember(Name = "include", EmitDefaultValue = false)]
        public string[] include;
    }

    public interface IEncryptedData
    {
        string EncryptedData { get; set; }
    }

    public interface IDisplayName
    {
        string DisplayName { get; set; }
    }

    [DataContract]
    public class EnterpriseNode : IEncryptedData, IDisplayName
    {
        [DataMember(Name = "node_id")]
        public long NodeId { get; set; }

        [DataMember(Name = "parent_id")]
        public long ParentId { get; set; }

        [DataMember(Name = "encrypted_data", EmitDefaultValue = false)]
        public string EncryptedData { get; set; }
        public string DisplayName { get; set; }
    }

    [DataContract]
    public class EnterpriseRole : IEncryptedData
    {
        [DataMember(Name = "role_id")]
        public long RoleId { get; set; }

        [DataMember(Name = "node_id")]
        public long NodeId { get; set; }

        [DataMember(Name = "encrypted_data", EmitDefaultValue = false)]
        public string EncryptedData { get; set; }

        [DataMember(Name = "visible_below", EmitDefaultValue = false)]
        public bool? VisibleBelow { get; set; }

        [DataMember(Name = "new_user_inherit", EmitDefaultValue = false)]
        public bool? NewUserInherit { get; set; }
    }

    [DataContract]
    public class EnterpriseRoleUser
    {
        [DataMember(Name = "role_id")]
        public long RoleId { get; set; }

        [DataMember(Name = "enterprise_user_id")]
        public long EnterpriseUserId { get; set; }
    }

    [DataContract]
    public class EnterpriseRoleKey
    {
        [DataMember(Name = "role_id")]
        public long RoleId { get; set; }
        [DataMember(Name = "encrypted_key")]
        public string EncryptedKey { get; set; }
        [DataMember(Name = "key_type")]
        public string KeyType { get; set; }
    }

    [DataContract]
    public class EnterpriseRoleKey2
    {
        [DataMember(Name = "role_id")]
        public long RoleId { get; set; }
        [DataMember(Name = "role_key")]
        public string RoleKey { get; set; }
    }

    [DataContract]
    public class EnterpriseTeam
    {
        [DataMember(Name = "team_uid")]
        public string TeamUid { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "node_id")]
        public long NodeId { get; set; }

        [DataMember(Name = "restrict_sharing")]
        public bool RestrictSharing { get; set; }

        [DataMember(Name = "restrict_edit")]
        public bool RestrictEdit { get; set; }

        [DataMember(Name = "restrict_view")]
        public bool RestrictView { get; set; }

        [DataMember(Name = "encrypted_team_key")]
        public string EncryptedTeamKey { get; set; }
    }

    [DataContract]
    public class EnterpriseTeamUser
    {
        [DataMember(Name = "team_uid")]
        public string TeamUid { get; set; }

        [DataMember(Name = "enterprise_user_id")]
        public long EnterpriseUserId { get; set; }
    }

    [DataContract]
    public class EnterpriseQueuedTeam : IEncryptedData
    {
        [DataMember(Name = "team_uid")]
        public string TeamUid { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "node_id")]
        public long NodeId { get; set; }

        [DataMember(Name = "encrypted_data")]
        public string EncryptedData { get; set; }
    }

    [DataContract]
    public class EnterpriseQueuedTeamUser
    {
        [DataMember(Name = "team_uid")]
        public string TeamUid { get; set; }

        [DataMember(Name = "users")]
        public ICollection<long> Users { get; set; }
    }

    [DataContract]
    public class EnterpriseUser : IEncryptedData, IDisplayName
    {
        [DataMember(Name = "enterprise_user_id")]
        public long EnterpriseUserId { get; set; }

        [DataMember(Name = "node_id")]
        public long NodeId { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "key_type")]
        public string KeyType { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "lock")]
        public int Lock { get; set; }

        [DataMember(Name = "account_share_expiration")]
        public decimal? AccountShareExpiration { get; set; }

        [DataMember(Name = "encrypted_data")]
        public string EncryptedData { get; set; }

        public string DisplayName { get; set; }
    }

    [DataContract]
    public class DeviceForAdminApproval
    {
        [DataMember(Name = "enterprise_user_id")]
        public long EnterpriseUserId { get; set; }

        [DataMember(Name = "encrypted_device_token")]
        public string EncryptedDeviceToken { get; set; }

        [DataMember(Name = "device_public_key")]
        public string DevicePublicKey { get; set; }

        [DataMember(Name = "device_name")]
        public string DeviceName { get; set; }

        [DataMember(Name = "client_version")]
        public string ClientVersion { get; set; }
    }

    [DataContract]
    public class EnterpriseKeys
    {
        [DataMember(Name = "rsa_public_key")]
        public string RsaPublicKey { get; set; }
        [DataMember(Name = "rsa_encrypted_private_key")]
        public string RsaEncryptedPrivateKey { get; set; }

        [DataMember(Name = "ecc_public_key")]
        public string EccPublicKey { get; set; }
        [DataMember(Name = "ecc_encrypted_private_key")]
        public string EccEncryptedPrivateKey { get; set; }
    }

    [DataContract]
    public class EnterpriseDataResponse : KeeperApiResponse
    {
        [DataMember(Name = "enterprise_name")]
        public string EnterpriseName { get; set; }

        [DataMember(Name = "tree_key")]
        public string TreeKey { get; set; }

        [DataMember(Name = "key_type_id")]
        public int KeyTypeId { get; set; }

        [DataMember(Name = "nodes")]
        public ICollection<EnterpriseNode> Nodes { get; set; }

        [DataMember(Name = "roles")]
        public ICollection<EnterpriseRole> Roles { get; set; }

        [DataMember(Name = "role_users")]
        public ICollection<EnterpriseRoleUser> RoleUsers { get; set; }

        [DataMember(Name = "role_keys")]
        public ICollection<EnterpriseRoleKey> RoleKeys { get; set; }

        [DataMember(Name = "role_keys2")]
        public ICollection<EnterpriseRoleKey2> RoleKeys2 { get; set; }

        [DataMember(Name = "teams")]
        public ICollection<EnterpriseTeam> Teams { get; set; }

        [DataMember(Name = "team_users")]
        public ICollection<EnterpriseTeamUser> TeamUsers { get; set; }

        [DataMember(Name = "queued_teams")]
        public ICollection<EnterpriseQueuedTeam> QueuedTeams { get; set; }

        [DataMember(Name = "queued_team_users")]
        public ICollection<EnterpriseQueuedTeamUser> QueuedTeamUsers { get; set; }

        [DataMember(Name = "users")]
        public ICollection<EnterpriseUser> Users { get; set; }

        [DataMember(Name = "devices_request_for_admin_approval")]
        public ICollection<DeviceForAdminApproval> DeviceRequestForApproval { get; set; }

        [DataMember(Name = "keys")]
        public EnterpriseKeys Keys { get; set; }
    }

    [DataContract]
    public class EncryptedData : IExtensibleDataObject
    {
        [DataMember(Name = "displayname", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }


    [DataContract]
    public class PreAccountTransferCommand : AuthenticatedCommand
    {
        public PreAccountTransferCommand() : base("pre_account_transfer") { }

        [DataMember(Name = "target_username", EmitDefaultValue = false)]
        public string TargetUsername { get; set; }
    }

    [DataContract]
    public class PreAccountTransferDataResponse : KeeperApiResponse
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "user_private_key")]
        public string UserPrivateKey { get; set; }

        [DataMember(Name = "role_key")]
        public string RoleKey { get; set; }

        [DataMember(Name = "role_key_id")]
        public long? RoleKeyId { get; set; }

        [DataMember(Name = "role_private_key")]
        public string RolePrivateKey { get; set; }

        [DataMember(Name = "transfer_key")]
        public string TransferKey { get; set; }
    }

    [DataContract]
    public class TeamAddCommand : AuthenticatedCommand
    {
        public TeamAddCommand(): base("team_add")
        {
        }

        [DataMember(Name = "team_uid")]
        public string TeamUid { get; set; }

        [DataMember(Name = "team_name")]
        public string TeamName { get; set; }

        [DataMember(Name = "restrict_share")]
        public bool RestrictShare { get; set; }

        [DataMember(Name = "restrict_edit")]
        public bool RestrictEdit { get; set; }

        [DataMember(Name = "restrict_view")]
        public bool RestrictView { get; set; }

        [DataMember(Name = "public_key", EmitDefaultValue = false)]
        public string PublicKey { get; set; }

        [DataMember(Name = "private_key", EmitDefaultValue = false)]
        public string PrivateKey { get; set; }

        [DataMember(Name = "node_id", EmitDefaultValue = false)]
        public long? NodeId { get; set; }

        [DataMember(Name = "team_key", EmitDefaultValue = false)]
        public string TeamKey { get; set; }

        [DataMember(Name = "manage_only", EmitDefaultValue = false)]
        public bool ManageOnly { get; set; }

        [DataMember(Name = "encrypted_team_key")]
        public string EncryptedTeamKey { get; set; }
    }

    [DataContract]
    public class ExecuteCommand : AuthenticatedCommand
    {
        public ExecuteCommand() : base("execute") { }

        [DataMember(Name = "requests", EmitDefaultValue = false)]
        public ICollection<KeeperApiCommand> Requests { get; set; }
    }

    [DataContract]
    public class ExecuteResponse : KeeperApiResponse
    {
        [DataMember(Name = "results")]
        public IList<KeeperApiResponse> Results { get; set; }
    }

    [DataContract]
    public class TeamGetKeysCommand : AuthenticatedCommand
    {
        public TeamGetKeysCommand() : base("team_get_keys") { }

        [DataMember(Name = "teams", EmitDefaultValue = false)]
        public string[] teams;
    }

    [DataContract]
    public class TeamKey
    {
        [DataMember(Name = "team_uid")]
        public string TeamUID { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "type")]
        public int KeyType { get; set; }

        [DataMember(Name = "result_code")]
        public string resultCode { get; set; }
    }

    [DataContract]
    public class TeamGetKeysResponse : KeeperApiResponse
    {
        [DataMember(Name = "keys")]
        public TeamKey[] TeamKeys { get; set; }
    }

    [DataContract]
    public class UserPublicKey
    {
        [DataMember(Name = "key_owner")]
        public string UserName { get; set; }

        [DataMember(Name = "public_key")]
        public string PublicKey { get; set; }

        [DataMember(Name = "result_code")]
        public string resultCode;

        [DataMember(Name = "message")]
        public string message;
    }

    [DataContract]
    public class PublicKeysCommand : AuthenticatedCommand
    {
        public PublicKeysCommand() : base("public_keys") { }

        [DataMember(Name = "key_owners", EmitDefaultValue = false)]
        public string[] key_owners;
    }

    [DataContract]
    public class PublicKeyResponse : KeeperApiResponse
    {
        [DataMember(Name = "public_keys")]
        public UserPublicKey[] PublicKeys { get; set; }
    }

    [DataContract]
    public class TeamEnterpriseUserAddCommand : AuthenticatedCommand
    {
        public TeamEnterpriseUserAddCommand(): base("team_enterprise_user_add")
        {
        }

        [DataMember(Name = "team_uid")]
        public string TeamUid { get; set; }

        [DataMember(Name = "enterprise_user_id")]
        public long EnterpriseUserId { get; set; }

        [DataMember(Name = "user_type")]
        public int UserType { get; set; }

        [DataMember(Name = "team_key", EmitDefaultValue = false)]
        public string TeamKey { get; set; }
    }

}
