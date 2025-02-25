CREATE EXTENSION IF NOT EXISTS "pgcrypto"; -- Para gerar UUID automaticamente

CREATE TABLE admin (
  admin_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  cpf VARCHAR(11) UNIQUE,
  rg VARCHAR(10) UNIQUE,
  cell VARCHAR(15),
  fullname TEXT,
  birthdate DATE,
  password TEXT,
  created_at TIMESTAMP DEFAULT now()
);

CREATE TABLE referee (
  referee_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  admin_id UUID REFERENCES admin(admin_id) ON DELETE CASCADE,
  cpf VARCHAR(11) UNIQUE,
  rg VARCHAR(10) UNIQUE,
  cell VARCHAR(15),
  fullname TEXT,
  birthdate DATE,
  password TEXT,
  created_at TIMESTAMP DEFAULT now()
);

CREATE TABLE athlete (
  athlete_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  cpf VARCHAR(11) UNIQUE,
  rg VARCHAR(10) UNIQUE,
  cell VARCHAR(15),
  fullname TEXT,
  birthdate DATE,
  weight FLOAT,
  gender VARCHAR(10),
  federate BOOLEAN,
  password TEXT,
  created_at TIMESTAMP DEFAULT now()
);

CREATE TABLE event (
  event_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  admin_id UUID UNIQUE REFERENCES admin(admin_id) ON DELETE CASCADE,
  date_id UUID UNIQUE REFERENCES dates(date_id) ON DELETE SET NULL,
  name TEXT,
  local TEXT,
  price_all FLOAT,
  price_federate FLOAT,
  created_at TIMESTAMP DEFAULT now()
);

CREATE TABLE dates (
  date_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  date_1 DATE,
  date_2 DATE,
  date_3 DATE,
  date_4 DATE
);

CREATE TABLE athlete_event (
  athlete_event_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  athlete_id UUID REFERENCES athlete(athlete_id) ON DELETE CASCADE,
  event_id UUID REFERENCES event(event_id) ON DELETE CASCADE,
  category TEXT, -- Criar tabela separada pode ser melhor
  sport TEXT, -- Criar tabela separada pode ser melhor
  payment BOOLEAN
);

CREATE TABLE athlete_historic (
  athlete_historic_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
  athlete_event_id UUID REFERENCES athlete_event(athlete_event_id) ON DELETE CASCADE,
  athlete_id UUID REFERENCES athlete(athlete_id) ON DELETE CASCADE,
  event_id UUID REFERENCES event(event_id) ON DELETE CASCADE,
  referee_1 BOOLEAN,
  referee_2 BOOLEAN,
  referee_3 BOOLEAN
);
