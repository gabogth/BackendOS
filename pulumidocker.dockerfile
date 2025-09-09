FROM pulumi/pulumi-dotnet:latest
WORKDIR /work/infra

COPY infra/ /work/infra/

COPY scripts/pulumi-entrypoint.sh /usr/local/bin/pulumi-entrypoint.sh
RUN chmod +x /usr/local/bin/pulumi-entrypoint.sh

ENTRYPOINT ["/usr/local/bin/pulumi-entrypoint.sh"]
CMD ["preview"]  # por defecto