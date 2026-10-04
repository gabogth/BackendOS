FROM pulumi/pulumi-dotnet:latest

WORKDIR /work

COPY . .
COPY ./Directory.Packages.props /work/nest.iac.generalinfra
COPY ./Directory.Packages.props /work/nest.core.security

WORKDIR /work/nest.iac.generalinfra

COPY ./nest.iac.generalinfra/pulumi_commands.sh /usr/local/bin/pulumi_commands.sh
RUN sed -i 's/\r$//' /usr/local/bin/pulumi_commands.sh && \
    chmod +x /usr/local/bin/pulumi_commands.sh

ENTRYPOINT ["/usr/local/bin/pulumi_commands.sh"]
#CMD ["/usr/local/bin/pulumi_commands.sh"]