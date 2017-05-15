CREATE TABLE public.tlinevoltages (
  id 	     serial NOT NULL,
  value      double precision NOT NULL,
  "date"     timestamp WITHOUT TIME ZONE NOT NULL DEFAULT timezone('utc'::text, now()),
  	
  CONSTRAINT tlinevoltages_pkey
    PRIMARY KEY (id)
) WITH (
    OIDS = FALSE
);
ALTER TABLE public.tlinevoltages
  OWNER TO application;
