SELECT * FROM ServerInfo;

SELECT st.OSName, si.ServerHostName, si.IpAddress, si.Description FROM ServerInfo si
JOIN ServerType st ON si.ServerTypeId = st.Id;

SELECT * FROM ServerService;

SELECT * FROM ServerServiceInfo;

SELECT ss.ServiceName, ss.Label, si.ServerHostName FROM ServerInfo si
JOIN ServerServiceInfo ssi ON ssi.ServerInfoId = si.Id
JOIN ServerService ss ON ssi.ServerServiceId = ss.Id
WHERE si.Id = 1;