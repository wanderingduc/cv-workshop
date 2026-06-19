import { CxIcon } from "@computas/designsystem/icon/react";
import { useUsers } from "../hooks/useUsers";
import { useUserExperiences } from "../hooks/useExperiences";
import { ExperienceCard } from "../components/experiences/ExperienceCard";
import styles from "./Home.module.css";
import portrettImage from "../assets/akersgata.jpg";

// Bruker #1 (seed-data): all erfaring tilhører denne brukeren.
const USER_ID = "11111111-1111-1111-1111-111111111111";

export default function Home() {
  const { data: users, isLoading, isError } = useUsers();
  const user = users?.find((u) => u.id === USER_ID) ?? users?.[0];
  const { data: experiences } = useUserExperiences(user?.id ?? "");

  if (isLoading) {
    return <div className={styles.state}>Laster …</div>;
  }

  if (isError || !user) {
    return <div className={styles.state}>Kunne ikke hente brukeren.</div>;
  }

  const sortedExperiences = [...(experiences ?? [])].sort(
    (a, b) => new Date(b.startDate).getTime() - new Date(a.startDate).getTime(),
  );

  return (
    <div className={styles.page}>
      <section className={styles.hero}>
        <img
          className={styles.image}
          src={user.imageUrl || portrettImage}
          alt={user.name}
        />

        <div className={styles.content}>
          <h1 className={`cx-title-1 ${styles.name}`}>{user.name}</h1>
          <p className={`cx-text-3 ${styles.university}`}>
            <CxIcon name="book" size="4" /> {user.university}
          </p>
          <p className={`cx-text-2-strong ${styles.tagline}`}>
            Bygger gode digitale opplevelser med kode og nysgjerrighet.
          </p>

          <p className={`cx-text-2 ${styles.description}`}>
            {user.description}
          </p>

          {user.skills?.length > 0 && (
            <p className={`cx-text-3 ${styles.skills}`}>
              {user.skills.map((skill) => skill.technology).join(" · ")}
            </p>
          )}

          {user.linkedInUrl && (
            <a
              className="cx-btn__secondary cx-btn__sm"
              href={user.linkedInUrl}
              target="_blank"
              rel="noreferrer"
            >
              LinkedIn
            </a>
          )}
        </div>
      </section>

      {sortedExperiences.length > 0 && (
        <section className={styles.timelineSection}>
          <h2 className={`cx-title-3 ${styles.timelineHeading}`}>Erfaring</h2>
          <ol className={styles.timeline}>
            {sortedExperiences.map((experience) => (
              <li key={experience.id} className={styles.timelineItem}>
                <span className={styles.dot} aria-hidden="true" />
                <div className={styles.timelineCard}>
                  <ExperienceCard experience={experience} />
                </div>
              </li>
            ))}
          </ol>
        </section>
      )}
    </div>
  );
}
