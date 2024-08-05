FROM mcr.microsoft.com/azure-sql-edge:1.0.7

USER root

# Install sqlcmd needed for HEALTHCHECK
RUN apt-get update \
    && apt-get install -y sudo gnupg software-properties-common \
    && add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/20.04/prod.list)" \
    && apt-get update \
    && apt-get install -y sqlcmd \
    && rm -rf /var/lib/apt/lists/*

USER mssql

ENV ACCEPT_EULA=1

# Healthcheck
# The container can be considered healthy when:
# - DB service (sqlservr) is running
# - .bacpac/dacpac deploy service (AsdePackage) has finished

HEALTHCHECK --interval=1s --timeout=10s --start-period=1s --retries=100 \
  CMD export SQLCMDPASSWORD="${MSSQL_SA_PASSWORD}" \
    && (sqlcmd -S localhost -U sa -Q "SELECT 1" || exit 1) \
    && ([ -f "/var/opt/mssql/DB_DEPLOYMENT_COMPLETE" ] && exit 0 || exit 1)

ENTRYPOINT ["/bin/sh", "-c", "(/app/asdepackage/AsdePackage && touch /var/opt/mssql/DB_DEPLOYMENT_COMPLETE) & /opt/mssql/bin/sqlservr"]