import { useQuery } from '@tanstack/react-query';
import { fetchExperiences, fetchExperiencesByUserId } from '../api';
import { Experience } from '../types/types';

export function useExperiences() {
  return useQuery({
    queryKey: ['experiences'],
    queryFn: fetchExperiences,
    select: (data: Experience[]) => data,
  });
}

export function useUserExperiences(userId: string) {
  return useQuery({
    queryKey: ['experiences', 'user', userId],
    queryFn: () => fetchExperiencesByUserId(userId),
    enabled: !!userId,
    select: (data: Experience[]) => data,
  });
}
