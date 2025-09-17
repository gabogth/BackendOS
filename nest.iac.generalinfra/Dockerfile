FROM pulumi/pulumi-dotnet:latest

WORKDIR /work/infra

COPY . /work/infra/

COPY pulumi_commands.sh /usr/local/bin/pulumi_commands.sh
RUN sed -i 's/\r$//' /usr/local/bin/pulumi_commands.sh && \
    chmod +x /usr/local/bin/pulumi_commands.sh

ENTRYPOINT ["/usr/local/bin/pulumi_commands.sh"]
#CMD ["/usr/local/bin/pulumi_commands.sh"]