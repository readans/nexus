USE master;

INSERT INTO
    Professors (Id, Name, Email)
VALUES (
        '2ac4b2e0-da60-4a8f-19b6-08ddf35089b3',
        'Dr. María González',
        'maria.gonzalez@universidad.edu'
    ),
    (
        '4e99024c-0f44-4bbf-6c2d-08ddf3f30e89',
        'Prof. Carlos Rodríguez',
        'carlos.rodriguez@universidad.edu'
    ),
    (
        'b1e225bf-93a2-47ff-6c2e-08ddf3f30e89',
        'Dra. Ana López',
        'ana.lopez@universidad.edu'
    ),
    (
        'b064f5ea-9517-4548-6c2f-08ddf3f30e89',
        'Prof. Luis Martínez',
        'luis.martinez@universidad.edu'
    ),
    (
        '95fafccb-8285-417e-6c30-08ddf3f30e89',
        'Dr. Elena Fernández',
        'elena.fernandez@universidad.edu'
    );

INSERT INTO
    Subjects (
        Id,
        Name,
        Code,
        Description,
        Credits,
        MaxStudents,
        ProfessorId
    )
VALUES (
        'b5eee75a-c512-4480-34fb-08ddf3670a31',
        'Matemáticas I',
        'MAT101',
        NULL,
        3,
        30,
        '2ac4b2e0-da60-4a8f-19b6-08ddf35089b3'
    ),
    (
        '2f1bb437-b885-4c11-dace-08ddf3f338be',
        'Física General',
        'FIS101',
        NULL,
        3,
        30,
        '2ac4b2e0-da60-4a8f-19b6-08ddf35089b3'
    ),
    (
        '4af0c665-f1ff-45a7-dacf-08ddf3f338be',
        'Programación I',
        'PRG101',
        NULL,
        3,
        30,
        '4e99024c-0f44-4bbf-6c2d-08ddf3f30e89'
    ),
    (
        '5fbbb2c2-f561-4176-dad0-08ddf3f338be',
        'Algoritmos y Estructuras de Datos',
        'PRG201',
        NULL,
        3,
        30,
        '4e99024c-0f44-4bbf-6c2d-08ddf3f30e89'
    ),
    (
        'e889d837-fc31-4068-dad1-08ddf3f338be',
        'Química General',
        'QUI101',
        NULL,
        3,
        30,
        'b1e225bf-93a2-47ff-6c2e-08ddf3f30e89'
    ),
    (
        '046f1f62-c420-410d-dad2-08ddf3f338be',
        'Química Orgánica',
        'QUI201',
        NULL,
        3,
        30,
        'b1e225bf-93a2-47ff-6c2e-08ddf3f30e89'
    ),
    (
        '54181763-34de-49c9-dad3-08ddf3f338be',
        'Historia Universal',
        'HIS101',
        NULL,
        3,
        30,
        'b064f5ea-9517-4548-6c2f-08ddf3f30e89	'
    ),
    (
        '2ad7bb4f-0751-4e2e-dad4-08ddf3f338be',
        'Literatura Española',
        'LIT101',
        NULL,
        3,
        30,
        'b064f5ea-9517-4548-6c2f-08ddf3f30e89'
    ),
    (
        '25011a87-f4fa-4279-dad5-08ddf3f338be',
        'Inglés Intermedio',
        'ING201',
        NULL,
        3,
        30,
        '95fafccb-8285-417e-6c30-08ddf3f30e89	'
    );
